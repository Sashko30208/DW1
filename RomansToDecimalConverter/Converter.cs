using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomansToDecimalConverter
{
    public interface IRomanConverter
    {
        //string Input { get; set; }
        string Output ( string s );
        int RomanToInt(string s);
        int ToDec(char c);
    }

    public class Converter : IRomanConverter
    {
        readonly int[] Arr = new int[] { 0, 1, 5, 10, 50, 100, 500, 1000 };//Used numbers
        /// <summary>
        /// Return the line with number or describes of error
        /// </summary>
        /// <param name="Input">The Number in Rome system of numbers</param>
        /// <returns>Returning value</returns>
        public string Output(string Input)
        {
            int temp=RomanToInt(Input);
            switch (temp)
            {
                case -1: return "Wrong input symbols"; 
                case -2: return "Incorrect sequence of numbers"; 
                case -3: return "Incredible mistake. Oopsie Doopsie (Empty Input)"; 
                default: return "Value is: "+temp.ToString();
            }
        }

        /// <summary>
        /// Variable with main logic of the program
        /// </summary>
        /// <param name="Input">The Rome number</param>
        /// <returns>Decimal number or error code</returns>
        public int RomanToInt(string Input)
        { 
            int len = Input.Length;
            if (len == 0) return -3;//Empty Input

            int[] intArr = new int[len+1];
            intArr[0] = 0;
            int summ=0;//temporary result of calculating
            //To transform it correct, we need to know 3 last symbols.
            int temp = 0;
            int temp2 = 0;
            int temp3 = 0;
            
            //Change Rome symbols to decimal and save it in intArr[]
            for (int i = len; i > 0;)
            {
                intArr[i] = ToDec(Input[i-1]);
                if (intArr[i] == 0)
                    return -1;//wrong symbol in Imput
                i--;
            }

            //
            for(int i=1; i <= len;) //&& err == 0;)
            {
                switch (i)
                {
                    case 1 : temp = intArr[1]; break;

                    case 2 :
                        if (Arr[intArr[1]] > Arr[intArr[2]])//первый больше второго - всё ок
                        { temp2 = temp; temp = intArr[2]; }
                        else
                        if (intArr[1] % 2 == 1)//if the first is even-numbered - all good
                        { temp2 = temp; temp = intArr[i]; }
                        else
                            return -2;break;

                    case 3:
                        if (Arr[intArr[2]] > Arr[intArr[3]])//second больше third - всё ок
                        { temp3 = temp2; temp2 = temp; temp = intArr[i]; }
                        else
                        if (Arr[intArr[1]] >= Arr[intArr[3]] && intArr[2] % 2 == 1)//if second is even-numbered and third less then a first - all good
                        { temp3 = temp2; temp2 = temp; temp = intArr[i]; }
                        else
                            return -2; break;
                    default:
                        if (Arr[intArr[i]] < Arr[temp])
                        {
                            if (Arr[temp3] >= Arr[temp2])
                                summ += Arr[temp3];
                            else
                                if (temp3 != 0)
                            {
                                summ += (Arr[temp2] - Arr[temp3]);
                                temp2 = 0;
                            }
                            temp3 = temp2;
                            temp2 = temp;
                            temp = intArr[i];
                        }
                        else
                        {
                            if ((temp % 2 == 0 ) || (temp2 < intArr[i]))
                            return -2;
                            if (Arr[intArr[i]] == Arr[temp])
                            {
                                if (Arr[temp3] == Arr[temp2] && Arr[temp2] == Arr[temp] && Arr[temp] == Arr[intArr[i]])
                                    return -2;
                                if (Arr[temp3] >= Arr[temp2])
                                    summ += Arr[temp3];
                                else
                                if (temp3 != 0)
                                {
                                    summ += (Arr[temp2] - Arr[temp3]);
                                    temp2 = 0;
                                }
                                temp3 = temp2;
                                temp2 = temp;
                                temp = intArr[i];
                            }

                            else
                            if (Arr[temp2] >= Arr[intArr[i]])
                            {
                                if (Arr[temp3] >= Arr[temp2])
                                    summ += Arr[temp3];
                                else
                                if (temp3 != 0)
                                {
                                    summ += (Arr[temp2] - Arr[temp3]);
                                    temp2 = 0;
                                }
                                temp3 = temp2;
                                temp2 = temp;
                                temp = intArr[i];
                            }
                            else
                                //err = -2; 
                                return -2;
                        }
                        break;
                }
                i++;
            }
     
            //calculating of result
            {
                if(temp3==0)
                {
                    if (temp2 == 0)
                        summ += Arr[temp];
                    else
                    if (Arr[temp2] >= Arr[temp])
                        summ += Arr[temp2] + Arr[temp];
                    else summ += Arr[temp] - Arr[temp2];
                }
                else
                {
                    if (Arr[temp3] >= Arr[temp2])
                    {
                        if (temp2 >= temp)
                            summ += Arr[temp3] + Arr[temp2] + Arr[temp];
                        else
                        { summ += Arr[temp3] + Arr[temp] - Arr[temp2]; }
                    }
                    else
                        summ += Arr[temp2] - Arr[temp3] + Arr[temp];
                }
               
            }
            return summ;
        }

        /// <summary>
        /// It returns a value of ROme number in decimal
        /// </summary>
        /// <param name="c">rome number</param>
        /// <returns>The same number in decimal number system</returns>
        public int ToDec(char c)
        {
            switch (c)
            {
                case 'I': return 1;
                case 'V': return 2;
                case 'X': return 3;
                case 'L': return 4;
                case 'C': return 5;
                case 'D': return 6;
                case 'M': return 7;
                default: return 0;
            }
        }
    }
}
