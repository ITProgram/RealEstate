using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Advertisement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserID { get; set; }     //автор
        //public User User { get; set; }
        public AdvertisementType Type { get; set; }///перыичка, аренда, вторичка

        public string Region { get; set; }      //область
        public string District { get; set; }    //район
        public string City { get; set; }        //город
        public string Street { get; set; }      //улица, микрорайон, проспект, переулок, 
        public string Housing { get; set; }     //корпус
        public int House { get; set; }          //дом
        public int Apartment { get; set; }      //квартира
        public double Latitude { get; set; }      //квартира
        public double Longitude { get; set; }      //квартира
        public double TotalArea { get; set; }       //общая площадь
        public double LivingArea { get; set; }      //жилая площадь
        public double KitchenArea { get; set; }     //кухни площадь
        public int RoomsNumber { get; set; }        //Количество комнат
        public int? ConstructionYear { get; set; }   //Год постройки
        public int Floor { get; set; }              //Этаж
        public int TotalFloors { get; set; }        //Всего этажей
        public bool Balcony { get; set; }    //балкон или лоджия

        public WallType? WallMaterial { get; set; }  //материал стен
        public WCType? WC { get; set; }              //туалет тип
        public bool Decoration { get; set; }        //отделка есть нет
        public double? CeilingHeight { get; set; }   //высота потолков


        public bool? Furniture { get; set; }        //мебель
        public bool? KitchenFurniture { get; set; } //мебель кухонная
        public bool? Stove { get; set; }             //плита
        public bool? Fridge { get; set; }           //холодильник
        public bool? WashingMachine { get; set; }   //стиральная машина
        public bool? TV { get; set; }                //TV
        public bool? Internet { get; set; }          //интернет
        public bool? AirConditioner { get; set; }    //концидионер
        public bool? Animals { get; set; }           //с Животными
        public bool? Students { get; set; }          //Студентам
        public bool Elevator { get; set; }          //Лифт




        public int Cost { get; set; }               //стоимость
        public string Description { get; set; }     //описание
        public string Phone { get; set; }        //контакты(ИМЯ НАПРИМЕР)

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:HH-mm-dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }  //дата создания
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:HH-mm-dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EditDate { get; set; }  //дата редактирования
    }
    //public enum BalconyType
    //{
    //    Balcony, Loggia
    //}
    public enum AdvertisementType
    {
        Rent, Sale, Resale
    }
    public enum WallType
    {
        Brick, Panel
    }
    public enum WCType
    {
        Combined, Separate, Street
    }

}
