using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC6.Models
{
    public class Note
    {
        /// <summary>
        ///  게시물 번호 
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        ///  게시물 제목 
        /// </summary>
        [Required]
        public string NoteTitle { get; set; }

        /// <summary>
        ///  게시물 내용 
        /// </summary>
        [Required]
        public string NoteContent { get; set; }

        /// <summary>
        ///   사용자 번호
        /// </summary>

        [ForeignKey("UserNo")]
        public virtual User USer { get; set; }
    }
}
