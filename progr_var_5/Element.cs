using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progr_var_5
{
    class Element
    {
        public double Value { get; set; }

        public Element Next { get; set; }

        public Element Prev { get; set; }

        public Element(double val)
        {
            Value = val;
            Next = null;
            Prev = null;
        }

        public Element() { }

        #region переопределение операторов

        public static bool operator >(Element e1, Element e2)
        {
            return e1.Value > e2.Value;
        }

        public static bool operator <(Element e1, Element e2)
        {
            return e1.Value < e2.Value;
        }

        public static bool operator >=(Element e1, Element e2)
        {
            return e1.Value >= e2.Value;
        }

        public static bool operator <=(Element e1, Element e2)
        {
            return e1.Value <= e2.Value;
        }
        
        public static _2List operator +(Element e1, Element e2)
        {
            if (e1 == null && e2 == null)
                return null;
            else
            {
                if (e1 == null || e2 == null)
                    if (e1 == null) return new _2List(e2.Value);
                    else return new _2List(e1.Value);
                else { _2List tmp = new _2List(e1.Value); tmp.Add(e2.Value); return tmp; }
            }
        }

        public override bool Equals(object obj)
        {
            var element = obj as Element;
            return element != null &&
                   Value == element.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + Value.GetHashCode();
        }

        public static bool operator ==(Element left, Element right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Element left, Element right)
        {
            return !Equals(left, right);

        }

        #endregion
    }
}
