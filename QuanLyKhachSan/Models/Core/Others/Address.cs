using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Others
{
    public enum CommueType { Ward, Commue, Township }
    public enum DistrictType { UrbanDistrict, RuralDistrict, Town, ProvincialCity }
    public enum ProvinceType { Province, Municipality }
    public class Address
    {
        public string Number { get; set; }

        public string Street { get; set; }

        public string Commue { get; set; }
        public CommueType CommueLevel { get; set; }

        public string District { get; set; }
        public DistrictType DistrictLevel { get; set; }

        public string Province { get; set; }
        public ProvinceType ProvinceLevel { get; set; }

        public Address(string number, string street, 
                       string commue, CommueType commueType,
                       string district, DistrictType districtType,
                       string province, ProvinceType provinceType)
        {
            Number = number;
            Street = street;
            Commue = commue;
            CommueLevel = commueType;
            District = district;
            DistrictLevel = districtType;
            Province = province;
            ProvinceLevel = provinceType;
        }

        public string GetVietnameseCommueType()
        {
            return CommueLevel switch {
                CommueType.Ward => "Phường",
                CommueType.Commue => "Xã",
                CommueType.Township => "Thị trấn",
                _ => ""
            };
        }

        public string GetVietnameseDistrictType()
        {
            return DistrictLevel switch
            {
                DistrictType.UrbanDistrict => "Quận",
                DistrictType.RuralDistrict => "Huyện",
                DistrictType.Town => "Thị xã",
                DistrictType.ProvincialCity => "Thành phố", //Thành phố trực thuộc tỉnh và thành phố trực thuộc thành phố trực thuộc trung ương
                _ => ""
            };
        }

        public string GetVietnameseProvinceType()
        {
            return ProvinceLevel switch { 
                ProvinceType.Province => "Tỉnh",
                ProvinceType.Municipality => "Thành phố", //Thành phố trực thuộc trung ương
                _ => ""
            };
        }

        public override string ToString()
        {
            return 
                $"{Number}, {Street}, " +
                $"{GetVietnameseCommueType()} {Commue}, " +
                $"{GetVietnameseDistrictType()} {District}, " +
                $"{GetVietnameseProvinceType()} {Province}";
        }
    }
}
