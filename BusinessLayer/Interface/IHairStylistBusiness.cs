using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public partial interface IHairStylistBusiness
    {
        bool CreateHairStylist(HairStylistModel hairstylist);
        bool UpdateHairStylist(HairStylistModel hairstylist);
        bool DeleteHairStylist(int hairstylistId);
        List<HairStylistModel> GetAllHairStylists();
        HairStylistModel GetHairStylistById(int hairstylistId);
    }
}
