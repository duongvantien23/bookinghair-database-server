using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class HairStylistBusiness : IHairStylistBusiness
    {
        private readonly IHairStylistRepository _hairStylistRepository;

        public HairStylistBusiness(IHairStylistRepository hairStylistRepository)
        {
            _hairStylistRepository = hairStylistRepository;
        }

        public bool CreateHairStylist(HairStylistModel hairstylist)
        {
            return _hairStylistRepository.Create(hairstylist);
        }

        public bool UpdateHairStylist(HairStylistModel hairstylist)
        {
            return _hairStylistRepository.Update(hairstylist);
        }

        public bool DeleteHairStylist(int hairstylistId)
        {
            return _hairStylistRepository.Delete(hairstylistId);
        }

        public List<HairStylistModel> GetAllHairStylists()
        {
            return _hairStylistRepository.GetAll();
        }

        public HairStylistModel GetHairStylistById(int hairstylistId)
        {
            return _hairStylistRepository.GetById(hairstylistId);
        }
    }
}
