using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Dates.Models;

[Table("invoices")]
public class DateFruitEntry : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("product_type")]
    public string ProductType { get; set; } = string.Empty;

    [Column("price_per_kilo")]
    public decimal PricePerKilo { get; set; }

    [Column("weight_kilos")]
    public decimal WeightKilos { get; set; }

    [Column("total_price")]
    public decimal TotalPrice { get; set; }

    [Column("box_count")]
    public int BoxCount { get; set; }

    [Column("supplier")]
    public string Supplier { get; set; } = string.Empty;

    [Column("purchase_date")]
    public DateTime PurchaseDate { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("is_paid")]
    public bool IsPaid { get; set; } // ✅ تم إصلاحه

    [Column("notes")]
    public string? Notes { get; set; }
}
