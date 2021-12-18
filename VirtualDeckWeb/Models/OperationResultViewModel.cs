using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public enum ModalMessageType
    {
        Success,
        Error
    }

    public class OperationResultViewModel
    {
        public ModalMessageType Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public OperationResultViewModel(ModalMessageType type, string title, string message)
        {
            Type = type;
            Title = title;
            Message = message;
        }
    }
}