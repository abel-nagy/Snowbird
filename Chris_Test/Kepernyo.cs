using System;
using System.Collections.Generic;
using System.Text;

namespace SnowbirdWallet
{
    abstract class Kepernyok
    {
        protected string s1;
        protected string s2;
        protected string gs1;
        protected string gs2;
        protected string gs3;
        protected string ls1;
        protected string ls2;
        protected string ls3;


        public Kepernyok(string oldalnev, string alkalmazasnev)
        {
            s1 = alkalmazasnev;
            s2 = oldalnev;
        }

        public abstract void Funkciok();
        
        /*public bool Ellenoriz()
        {
            string a;
            return a;
        }*/
    }

}