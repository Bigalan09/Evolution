using Evolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Evolution.Genetics
{
    class Gene
    {
        private static readonly Regex binary = new Regex("^[01]{1,32}$", RegexOptions.Compiled);
        private const int maxValue = 100;

        private PropertyType type;
        private int value = 0;      
        private string binaryString = "";

        public PropertyType Type
        {
            get { return type; }
        }

        public int Value
        {
            get { return this.value; }
        }

        public string BinaryString
        {
            get { return binaryString; }
        }

        public Gene(PropertyType type, int value)
        {
            this.type = type;
            this.value = value;
            this.binaryString = IntToBinary(value);
        }

        public Gene(PropertyType type, string binaryString)
        {
            this.type = type;
            this.value = BinaryToInt(binaryString);
            this.binaryString = binaryString.PadLeft(8, '0');
        }

        public void Mutate() {
            this.value = Randomiser.nextInt() % maxValue;
            this.binaryString = IntToBinary(this.value);
        }

        private string IntToBinary(int n)
        {
            char[] b = new char[8];
            int pos = 7;
            int i = 0;

            while (i < 8)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }

        private int BinaryToInt(string b)
        {
            if (binary.IsMatch(b))
            {
                return Convert.ToInt32(b, 2);
            }
            else
            {
                Console.WriteLine("invalid: " + b);
            }
            return -1;
        }

        public override string ToString()
        {
            return "[Gene][type: " + type + " , value: " + value + ", binary: " + binaryString + "]\n";
        }
    }
}
