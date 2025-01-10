using PrBeleBackend.Core.DTO.AttributeDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class AttributeValue
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public int AttributeTypeId { get; set; }
        public AttributeType? AttributeType {  get; set; } 
        public int Status { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<VariantAttributeValue>? VariantAttributeValues { get; set; }
    }

    public static class AttributeValueExtension
    {
        public static AttributeValue ToAttributeValue(this AttributeValueResponse attrValueRes)
        {
            return new AttributeValue
            {
                Id = attrValueRes.Id,
                Name = attrValueRes.Name,
                Value = attrValueRes.Value,
                //Deleted = attrValueRes.Deleted,
                CreatedAt = attrValueRes.CreatedAt,
                UpdatedAt = attrValueRes.UpdatedAt
            };
        }

        public static AttributeValue ToAttributeValue(this AttributeValueAdderRequest attrValueReq)
        {
            return new AttributeValue
            {
                AttributeTypeId = attrValueReq.AttributeTypeId,
                Name = attrValueReq.Name,
                Value = attrValueReq.Value,
                //Status = attrValueReq.Status,
                Deleted = false,
            };
        }

        public static AttributeValue ToAttributeValue(this AttributeValueUpdaterRequest attrValueReq)
        {
            return new AttributeValue
            {
                Name = attrValueReq.Name,
                Value = attrValueReq.Value,
            };
        }
    }
}
