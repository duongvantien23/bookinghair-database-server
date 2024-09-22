using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public partial interface IHairStylistRepository
    {
        bool Create(HairStylistModel hairstylist);
        bool Update(HairStylistModel hairstylist);
        bool Delete(int hairstylistId);
        List<HairStylistModel> GetAll();
        HairStylistModel GetById(int hairstylistId);
    }
}
