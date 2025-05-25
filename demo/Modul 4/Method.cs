using demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Modul_4
{
    class Method
    {
        public static int MatherialCount(int prodType, int matherId, int quantity, int par1, int par2)
        {
            var productTyp = Entities.GetContext().ProductType.Where(x => x.Id == prodType);
            var matherTyp = Entities.GetContext().MaterialType.Where(x => x.Id == matherId);
            if (productTyp.Count()<1 || matherTyp.Count()<1 || quantity<1 || par1 <= 0 || par2 <= 0)
            {
                return -1;
            }

            double answ;
            double koeff = Entities.GetContext().ProductType.Select(x => x.Coefficient).FirstOrDefault();
            double deff = Entities.GetContext().MaterialType.Select(x => x.DefectPercent).FirstOrDefault();
            double matherCount = par1 * par2 * koeff;

            answ = matherCount + matherCount * deff;
            return (int) Math.Ceiling(answ);

        }
    }
}
