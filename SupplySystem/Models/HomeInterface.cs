using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplySystem.Models
{
    public interface HomeInterface
    {
        string FORM_NAME { get; set; }
        bool HasPrint  { get; set; }
        void BtnNew();
        void BtnNewFrom();
        void BtnUpdate();
        void BtnDelete();
        void BtnRefresh();
        void BtnUndo();
        void BtnSave();
        string UserValid();
        void ToolsEnabeld(bool isenabeld);
        void BtnPrint();
    }
}