﻿using System;
using System.Text.RegularExpressions;

namespace L7
{
    class RacionalNumber : IComparable<RacionalNumber>, IEquatable<RacionalNumber>
    {
        private readonly long n;
        private readonly long m;
        private static long FindGCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0) return b;
            else if (b == 0) return a;
            else if (a == b) return a;
            else if (a == 1 || b == 1) return 1;
            else if ((a % 2 == 0) && (b % 2 == 0)) return 2 * FindGCD(a / 2, b / 2);
            else if ((a % 2 == 0) && (b % 2 != 0)) return FindGCD(a / 2, b);
            else if ((a % 2 != 0) && (b % 2 == 0)) return FindGCD(a, b / 2);
            else return FindGCD(b, (int)Math.Abs(a - b));
        }

        public RacionalNumber(long _n, long _m)
        {
            long GCD = FindGCD(_n, _m);
            n = _n / GCD;
            m = _m / GCD;
        }

        public int CompareTo(RacionalNumber num_2)
        {
            if ((double)this > (double)num_2)
                return 1;
            else if ((double)this < (double)num_2)
                return -1;
            else
                return 0;
        }

        public int CompareTo(object other)
        {
            if (other is RacionalNumber)
                return CompareTo((RacionalNumber)other);
            else
                throw new InvalidOperationException("CompareTo: not a rational number");
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }
            if (other is RacionalNumber)
            {
                return Equals((RacionalNumber)other);
            }
            return false;
        }

        public bool Equals(RacionalNumber other)
        {
            if (other == null)
                return false;
            else
                return (n == other.n && m == other.m);
        }

        public override int GetHashCode()
        {
            return (int)(n * 17 + m);
        }

        public static RacionalNumber operator +(RacionalNumber num_1, RacionalNumber num_2)
        {
            long mm_GCD = FindGCD(num_1.m, num_2.m);
            long new_n = num_1.n * (num_2.m / mm_GCD) + num_2.n * (num_1.m / mm_GCD);
            long new_m = num_1.m * (num_2.m / mm_GCD);
            long nm_GCD = FindGCD(new_n, new_m);
            return new RacionalNumber(new_n / nm_GCD, new_m / nm_GCD);
        }

        public static RacionalNumber operator -(RacionalNumber num_1, RacionalNumber num_2)
        {
            long mm_GCD = FindGCD(num_1.m, num_2.m);
            long new_n = num_1.n * (num_2.m / mm_GCD) - num_2.n * (num_1.m / mm_GCD);
            long new_m = num_1.m * (num_2.m / mm_GCD);
            long nm_GCD = FindGCD(new_n, new_m);
            return new RacionalNumber(new_n / nm_GCD, new_m / nm_GCD);
        }

        public static RacionalNumber operator *(RacionalNumber num_1, RacionalNumber num_2)
        {
            long new_n = num_1.n * num_2.n;
            long new_m = num_1.m * num_2.m;
            long nm_GCD = FindGCD(new_n, new_m);
            return new RacionalNumber(new_n / nm_GCD, new_m / nm_GCD);
        }

        public static RacionalNumber operator /(RacionalNumber num_1, RacionalNumber num_2)
        {
            long new_n = num_1.n * num_2.m;
            long new_m = num_1.m * num_2.n;
            long nm_GCD = FindGCD(new_n, new_m);
            return new RacionalNumber(new_n / nm_GCD, new_m / nm_GCD);
        }

        public static bool operator <(RacionalNumber num_1, RacionalNumber num_2)
        {
            return num_1.CompareTo(num_2) < 0;
        }

        public static bool operator >(RacionalNumber num_1, RacionalNumber num_2)
        {
            return num_1.CompareTo(num_2) > 0;
        }

        public static bool operator <=(RacionalNumber num_1, RacionalNumber num_2)
        {
            return num_1.CompareTo(num_2) <= 0;
        }

        public static bool operator >=(RacionalNumber num_1, RacionalNumber num_2)
        {
            return num_1.CompareTo(num_2) >= 0;
        }

        public static explicit operator long(RacionalNumber num)
        {
            return num.n / num.m;
        }

        public static explicit operator double(RacionalNumber num)
        {
            return (double)num.n / num.m;
        }

        public string RationalToString()
        {
            string str = $"{n}/{m}";
            return str;
        }

        public string ToString()
        {
            string str = $"{n / m}";
            return str;
        }

        public static RacionalNumber StringToRational(string str)
        {
            string pattern1 = @"^\d{1,9}\s*\/\s*\d{1,9}$";
            string pattern2 = @"^\d{1,9}\s*\.\s*\d{1,9}$";
            if (Regex.IsMatch(str, pattern1))
            {

                string[] numbers = str.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
                long n = long.Parse(numbers[0]);
                long m = long.Parse(numbers[1]);
                if (m == 0)
                {
                    Console.WriteLine("The denominator cannot be equal to zero");
                    return null;
                }
                else
                {
                    return new RacionalNumber(n, m);
                }
            }
            else if (Regex.IsMatch(str, pattern2))
            {
                string[] numbers = str.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                long n = long.Parse(numbers[0] + numbers[1]);
                long m = (long)Math.Pow(10, numbers[1].Length);
                if (m == 0)
                {
                    Console.WriteLine("The denominator cannot be equal to zero");
                    return null;
                }
                else
                {
                    return new RacionalNumber(n, m);
                }
            }
            else
            {
                return null;
            }
        }
    }    
}
