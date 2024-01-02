
using OnlineStore.Utilities.Helpers.GuidHelper;
using System.Security.Cryptography;

namespace OnlineStore.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string root, string filePath)
        {
            if (!File.Exists(root+file.FileName))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            string extension=Path.GetExtension(file.FileName);
            string guid = GuidHelper.GuidHelper.CreateGuid();
            string fileName = guid + extension;
            using (FileStream fileStream=new FileStream(Path.Combine(root,fileName),FileMode.Create))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                #region flush
                // u, daha verimli bir işlem yapılabilmesi için önemlidir. Yani, bir dosyaya yazıldığında veya bir dosyadan okunduğunda, veri önce bellekte biriktirilir ve daha sonra disk üzerindeki dosyaya gerçekten yazılır veya diskten okunur.

                //Ancak, bazı durumlarda bu arabellek dosyaya yazılmadan önce boşaltılmaz. Örneğin, dosyaya yazma işlemi büyük miktarda veri içeriyorsa veya belirli bir zamanda verinin disk üzerinde olması kritikse, veri bellekte toplandıktan sonra hemen disk üzerindeki dosyaya yazılması gerekebilir.

                //fileStream.Flush() bu noktada devreye girer. Bu komut, dosyaya yazılmamış olan veriyi, dosya akışındaki önbellekten hemen disk üzerindeki dosyaya yazar. Bu işlem, dosyaya yazma işleminin anlık olarak yapılmasını sağlar ve özellikle beklenmedik bir durumda(örneğin, program çökmesi gibi) veri kaybını önler.

                //Kısacası, Flush() metodu, dosya akışındaki önbelleği boşaltarak, bellekte bekleyen verinin hemen dosyaya yazılmasını sağlar. Bu da verinin disk üzerinde güncel ve tutarlı olmasını sağlar.
                #endregion
                
            }
            return @"\img\" + fileName;
        }
    }
}
