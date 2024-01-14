using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.Concrete
{
    public enum EnumOrderState
    {
        [Display(Name ="Onay Bekleniyor.")]
        Waiting,
        [Display(Name = "Kargoya Verildi.")]
        Shipped,
        [Display(Name = "Sipariş Tamamlandı.")]
        Completed,
        [Display(Name = "Sipariş İptal Edildi.")]
        Canceled
    }
}
