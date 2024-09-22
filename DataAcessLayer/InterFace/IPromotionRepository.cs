using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public partial interface IPromotionRepository
    {
        bool Create(PromotionModel promotion);
        bool Update(PromotionModel promotion);
        bool Delete(int promotionId);
        List<PromotionModel> GetAll();
        PromotionModel GetById(int promotionId);
    }
}
