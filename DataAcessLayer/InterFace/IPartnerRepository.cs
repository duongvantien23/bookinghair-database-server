using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.InterFace
{
    public partial interface IPartnerRepository
    {
        bool Create(PartnerModel partner);
        bool Update(PartnerModel partner);
        bool Delete(int partnerId);
        List<PartnerModel> GetAll();
        PartnerModel GetById(int partnerId);
    }
}
