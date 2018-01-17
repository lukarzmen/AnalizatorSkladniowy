using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizatorSkladniowy
{
    public class AnalizatorSkladniowy
    {
        private char[] analizowanyCiag;
        int indeksZnakuWAnalizowanymCiagu;
        private char[] firstZ = { '(', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] firstWp = { '+','-',':','*','^' };
        private char[] firstRp = { '.' };
        private char[] firstLp = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        char AktualnieAnalizowanyZnak => analizowanyCiag[indeksZnakuWAnalizowanymCiagu];

        public AnalizatorSkladniowy(string tekstDoAnalizy)
        {
            this.analizowanyCiag = tekstDoAnalizy.ToCharArray();
            indeksZnakuWAnalizowanymCiagu = 0;
        }

        public void Analizuj()
        {
            S();
        }

        private void S()
        {
            W();
            if (AktualnieAnalizowanyZnak == ';')
                indeksZnakuWAnalizowanymCiagu++;
            else
                throw new BladSkladniowy();
            Z();
        }

        private void Z()
        {
            if (!firstZ.Contains(AktualnieAnalizowanyZnak))
                return;
            W();
            if (AktualnieAnalizowanyZnak == ';')
                indeksZnakuWAnalizowanymCiagu++;
            else
                throw new BladSkladniowy();
            Z();
        }

        private void W()
        {
            P();
            Wp();
        }

        private void Wp()
        {
            if (!firstWp.Contains(AktualnieAnalizowanyZnak))
                return;

            O();
            W();
        }
        private void P()
        {
            
            if (AktualnieAnalizowanyZnak == '(')
            {
                indeksZnakuWAnalizowanymCiagu++;
                W();
                if (AktualnieAnalizowanyZnak == ')')
                    indeksZnakuWAnalizowanymCiagu++;
                else
                    throw new BladSkladniowy();
            }
            else
                R();
            
        }

        private void R()
        { 
            L();
            Rp();
        }
        private void Rp()
        {
            if (!firstRp.Contains(AktualnieAnalizowanyZnak))
                return;
            if (AktualnieAnalizowanyZnak == '.')
            {
                indeksZnakuWAnalizowanymCiagu++;
                L();
            }
            else
                throw new BladSkladniowy();
        }

        private void L()
        { 
            C();
            Lp();
        }

        private void Lp()
        {
            if (!firstLp.Contains(AktualnieAnalizowanyZnak))
                return;
            L();

        }
        private void O()
        {
            switch(AktualnieAnalizowanyZnak)
            {
                case '*':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case ':':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '+':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '-':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '^':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                default:
                    throw new BladSkladniowy();
            }           

        }

        private void C()
        {
            switch (AktualnieAnalizowanyZnak)
            {
                case '0':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '1':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '2':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '3':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '4':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '5':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '6':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '7':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '8':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                case '9':
                    indeksZnakuWAnalizowanymCiagu++;
                    break;
                default:
                    throw new BladSkladniowy();
            }
        }
    }
}
