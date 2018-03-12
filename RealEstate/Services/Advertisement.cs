using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Services
{
    public class Advertisement : IAdvertisement
    {
        protected readonly RealEstateContext _context;

        public Advertisement(RealEstateContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Advertisement> GetAdvertisements([FromQuery] int? userId)
        {
            return _context.Advertisements.Where(ad => ad.UserID.Equals(userId ?? ad.UserID));
            //throw new NotImplementedException();
        }


        public async Task<Models.Advertisement> GetAdvertisementById(int advertisementId)
        {
            return await _context.Advertisements.SingleOrDefaultAsync(advertisement => advertisement.ID == advertisementId);
        }

        public async Task<Models.Advertisement> CreateAdvertisement(Models.Advertisement advertisement)
        {
            //Models.Advertisement creatingAdvertisement = new Models.Advertisement
            //{
            //    Login = user.Login,
            //    Email = user.Email
            //};
            //creatingUser.Password = new PasswordHasher<Models.User>().HashPassword(creatingUser, user.Password);
            EntityEntry<Models.Advertisement> createdAdvertisement = await _context.Advertisements.AddAsync(advertisement);
            await _context.SaveChangesAsync();
            return createdAdvertisement.Entity;

        }

        public async Task<Models.Advertisement> UpdateAdvertisement(Models.Advertisement advertisement, int advertisementId)///TODO ads update???
        {
            Models.Advertisement existingAdvertisement = await _context.Advertisements.SingleOrDefaultAsync(a => a.ID == advertisementId);
            if (advertisement.Latitude > 0) existingAdvertisement.Latitude = advertisement.Latitude;
            if (advertisement.Longitude > 0) existingAdvertisement.Longitude = advertisement.Longitude;

            if (advertisement.TotalArea > 0) existingAdvertisement.TotalArea = advertisement.TotalArea;
            if (advertisement.KitchenArea > 0) existingAdvertisement.KitchenArea = advertisement.KitchenArea;
            if (advertisement.KitchenArea > 0) existingAdvertisement.KitchenArea = advertisement.KitchenArea;
            if (advertisement.LivingArea > 0) existingAdvertisement.LivingArea = advertisement.LivingArea;
            if (advertisement.Balcony) existingAdvertisement.Balcony = advertisement.Balcony;
            if (advertisement.TV != null) existingAdvertisement.TV = advertisement.TV;
            existingAdvertisement.Balcony = advertisement.Balcony;
            existingAdvertisement.Elevator = advertisement.Elevator;
            existingAdvertisement.TV = advertisement.TV;
            existingAdvertisement.AirConditioner = advertisement.AirConditioner;
            existingAdvertisement.Fridge = advertisement.Fridge;
            existingAdvertisement.Stove = advertisement.Stove;
            if (advertisement.Type != null) existingAdvertisement.Type = advertisement.Type;
            if (!String.IsNullOrEmpty(advertisement.Region)) existingAdvertisement.Region = advertisement.Region;
            if (!String.IsNullOrEmpty(advertisement.Housing)) existingAdvertisement.Housing = advertisement.Housing;
            if (!String.IsNullOrEmpty(advertisement.City)) existingAdvertisement.City = advertisement.City;
            if (advertisement.House > 0) existingAdvertisement.House = advertisement.House;
            if (advertisement.Apartment > 0) existingAdvertisement.Apartment = advertisement.Apartment;
            if (!String.IsNullOrEmpty(advertisement.District)) existingAdvertisement.District = advertisement.District;
            if (!String.IsNullOrEmpty(advertisement.Street)) existingAdvertisement.Street = advertisement.Street;
            if (advertisement.RoomsNumber > 0) existingAdvertisement.RoomsNumber = advertisement.RoomsNumber;
            if (advertisement.ConstructionYear > 0) existingAdvertisement.ConstructionYear = advertisement.ConstructionYear;
            if (advertisement.Floor > 0) existingAdvertisement.Floor = advertisement.Floor;
            if (advertisement.TotalFloors > 0) existingAdvertisement.TotalFloors = advertisement.TotalFloors;
            if (advertisement.Cost > 0) existingAdvertisement.Cost = advertisement.Cost;
            existingAdvertisement.EditDate = DateTime.Now;



            EntityEntry<Models.Advertisement> updatedAdvertisement = _context.Advertisements.Update(existingAdvertisement);
            await _context.SaveChangesAsync();
            return updatedAdvertisement.Entity;
        }
        public async Task<Models.Advertisement> DeleteAdvertisement(int advertisementId)
        {
            Models.Advertisement existingAdvertisement = await _context.Advertisements.SingleOrDefaultAsync(advertisement => advertisement.ID == advertisementId);
            if (existingAdvertisement == null)
            {
                return null;
            }
            EntityEntry<Models.Advertisement> deletingAdvertisement = _context.Advertisements.Remove(existingAdvertisement);
            await _context.SaveChangesAsync();
            return deletingAdvertisement.Entity;
        }




    }

}
