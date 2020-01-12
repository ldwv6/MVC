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
        [Required(ErrorMessage ="사용자 이름을 입력하세요")]
        public string UserName { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        /// </summary>
        [Required(ErrorMessage = "사용자 ID을 입력하세요")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "사용자 패스워드을 입력하세요")]
        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        public string UserPassword { get; set; }
    }
}
