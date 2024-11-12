using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public partial interface IPartnerBusiness
    {
        bool CreatePartner(PartnerModel partner);
        bool UpdatePartner(PartnerModel partner);
        bool DeletePartner(int partnerId);
        List<PartnerModel> GetAllPartners();
        PartnerModel GetPartnerById(int partnerId);
    }
}
