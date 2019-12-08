using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.Models
{
    public class User
    {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key]
        public int UserNo { get; set; }

        /// <summary>
        ///  사용자 이름
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        public string UserID { get; set; }

        [Required]
        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        public string UserPassword { get; set; }
    }
}
