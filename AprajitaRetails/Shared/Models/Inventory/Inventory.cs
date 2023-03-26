using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprajitaRetails.Shared.Models.Inventory
{

    public class Tax
    {
        [Key]
        public int TaxNameId { get; set; }
        public string Name { get; set; }
        public TaxType TaxType { get; set; }
        public decimal CompositeRate { get; set; }
        public bool OutPutTax {get;set;}
    }

public class ProductItem
{
    [Key]
    public string Barcode { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public string? StyleCode { get; set; }

    public TaxType TaxType { get; set; }
    public decimal MRP { get; set; }
    public Size Size { get; set; }

    //Category
    public ProductCategory ProductCategory { get; set; }

    public string SubCategory { get; set; }
    public string? ProductTypeId { get; set; }

    public string? HSNCode { get; set; }
    public Unit Unit { get; set; }

    public string? BrandCode { get; set; }

    //FKs
    [ForeignKey("BrandCode")]
    public virtual Brand Brand { get; set; }

    [ForeignKey("SubCategory")]
    public virtual ProductSubCategory ProductSubCategory { get; set; }

    [ForeignKey("ProductTypeId")]
    public virtual ProductType ProductType { get; set; }
}

public class ProductType
{
    [Key]
    public string ProductTypeId { get; set; }

    public string ProductTypeName { get; set; }
}

public class ProductSubCategory
{
    [Key]
    public string SubCategory { get; set; }

    public ProductCategory ProductCategory { get; set; }
}

//[Table("V1_Brands")]
public class Brand
{
    [Key]
    public string BrandCode { get; set; }

    public string BrandName { get; set; }
}
}