using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.Data.RequestDtos { 

    public class MessageForCreationRequestDto
    {
        public int SenderId { get; set; }
        public int recipientId { get; set; }
        public DateTime MessageSent { get; set; }
        public string Content { get; set; }

        public MessageForCreationRequestDto()
        {
            MessageSent = DateTime.Now;
        }
    }
}
