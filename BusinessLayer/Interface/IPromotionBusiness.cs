using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public partial interface IPromotionBusiness
    {
        bool CreatePromotion(PromotionModel promotion);
        bool UpdatePromotion(PromotionModel promotion);
        bool DeletePromotion(int promotionId);
        List<PromotionModel> GetAllPromotions();
        PromotionModel GetPromotionById(int promotionId);
    }
}
