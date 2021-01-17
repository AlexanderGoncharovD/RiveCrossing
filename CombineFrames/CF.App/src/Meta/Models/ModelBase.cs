using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Models
{
    public class ModelBase
    {
        protected string Tab { get; private set; }

        public virtual string Print(int tabSize)
        {
            SetTab(tabSize);
            return ToString();
        }

        private void SetTab(int tabSize)
        {
            for (var i = 0; i < tabSize; i++)
            {
                Tab += " ";
            }
        }
    }
}
