using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public interface IAdvertisement
    {
        IEnumerable<Models.Advertisement> GetAdvertisements(int? userId);
        Task<Models.Advertisement> GetAdvertisementById(int advertisementId);
        Task<Models.Advertisement> CreateAdvertisement(Models.Advertisement Advertisement);
        Task<Models.Advertisement> UpdateAdvertisement(Models.Advertisement advertisementm, int advertisementId);
        Task<Models.Advertisement> DeleteAdvertisement(int AdvertisementId);
    }
}
