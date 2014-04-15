using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MicroGrapher4
{
    struct FunctionRepr
    {    /*
         *  Is a value type which boxes the function;
         *  Other objects do not interact with the function except by using 
         *  the GetValueAtPoint Method
         */

        private List<Member> functionMembers;

        public FunctionRepr(string input)
        {
            input = new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());

            functionMembers = new List<Member>();

            string[] members = Regex.Split(input, @"(?=[+,-])");

            for (int i = 0; i < members.Length; i++)
            {
                functionMembers.Add(new Member(members[i]));
            }


            //END OF
        }

        public double GetValueAtPoint(double point)
        {
            double value = 0;

            foreach (IsFunctionBaseMember member in functionMembers)
            {
                if (member is Member)
                {
                    value += ((Member)member).GetValue(point);
                }
            }

            return value;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (IsFunctionBaseMember member in functionMembers)
            {
                output.Append(member.ToString());
            }

            return output.ToString();
        }


    }

    interface IsFunctionBaseMember
    {

    }

    struct MemberSign
    {
        private int _sign;
        public MemberSign(char sign)
        {
            if (sign == '-')
                _sign = -1;
            else
                _sign = 1;
        }
        public int sign { get { return _sign; } }

        public override string ToString()
        {
            if (_sign == -1)
                return "-";
            else
                return "+";
        }
    }

    struct Member : IsFunctionBaseMember
    {
        private bool isVar;
        private double value;
        private double degree;
        private Variable variable;
        private MemberSign sign;

        public Member(string input)
        {


            isVar = !Double.TryParse(input, out value);

            if (isVar)
            {
                Match match = Regex.Match(input, @"(\d*)(\D*)");

                if (!Double.TryParse(match.Groups[1].Value, out value))
                    value = 1;
                variable = new Variable(match.Groups[2].Value);
            }
            else
            {
                variable = new Variable("NULL");
            }

            sign = new MemberSign(input.ToCharArray()[0]);

            //Change to Regex:
            char[] chArr = input.ToCharArray(); char degree = '1';
            for (int i = 0; i < chArr.Length - 1; i++)
                if (chArr[i] == '^')
                    degree = chArr[i + 1];
            this.degree = Double.Parse(new string(new char[] {degree}));
                    
             //--
        }
        public double GetValue(double input)
        {
            if (isVar){
                return Math.Pow(value * input * sign.sign, degree);
            }
            else{
                return Math.Pow(this.value,degree);
            }
                
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(sign.ToString());
            output.Append(value.ToString());
            if (isVar)
                output.Append(variable.ToString());
            if (this.degree != 1)
                output.Append(this.degree.ToString() );

            return output.ToString();
        }
    }
    struct Variable
    {
        string var;
        public Variable(string input)
        {
            var = input;
        }
        public override string ToString()
        {
            return var;
        }
    }
}

