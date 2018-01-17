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
        private readonly int dlugoscCiagu;

        char AktualnieAnalizowanyZnak => analizowanyCiag[indeksZnakuWAnalizowanymCiagu];

        public AnalizatorSkladniowy(string tekstDoAnalizy)
        {
            this.analizowanyCiag = tekstDoAnalizy.ToCharArray();
            indeksZnakuWAnalizowanymCiagu = 0;
            this.dlugoscCiagu = tekstDoAnalizy.Count();
        }

        public void Analizuj()
        {
            S();
        }

        private void S()
        {
            if (CzyZakonczonoCiag())
                return;
            W();
            if (AktualnieAnalizowanyZnak == ';')
                indeksZnakuWAnalizowanymCiagu++;
            else
                throw new BladSkladniowy();
            Z();
        }

        private void Z()
        {
            if (CzyZakonczonoCiag())
                return;
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
            if (CzyZakonczonoCiag())
                return;
            P();
            Wp();
        }

        private void Wp()
        {
            if (CzyZakonczonoCiag())
                return;
            if (!firstWp.Contains(AktualnieAnalizowanyZnak))
                return;

            O();
            W();
        }
        private void P()
        {
            if (CzyZakonczonoCiag())
                return;
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
            if (CzyZakonczonoCiag())
                return;
            L();
            Rp();
        }
        private void Rp()
        {
            if (CzyZakonczonoCiag())
                return;
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
            if (CzyZakonczonoCiag())
                return;
            C();
            Lp();
        }

        private void Lp()
        {
            if (CzyZakonczonoCiag())
                return;
            if (!firstLp.Contains(AktualnieAnalizowanyZnak))
                return;
            L();

        }
        private void O()
        {
            if (CzyZakonczonoCiag())
                return;
            switch (AktualnieAnalizowanyZnak)
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
            if (CzyZakonczonoCiag())
                return;
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

        private bool CzyZakonczonoCiag()
        {
            return indeksZnakuWAnalizowanymCiagu > dlugoscCiagu -1;
        }
    }
}
