using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obout.ComboBox;
using System.Data;
using Telerik.Web.UI;



/// <summary>
/// Summary description for GridCellControls
/// </summary>
namespace RFQDBFunctions
{
    public class GridCellControls
    {
        const int TEXTBOXCELLWIDTH = 400;
        const int TEXTBOXNOTEHEIGHT = 300;

        public GridCellControls()
        {


        }
        public Control   GetGridCellControl(string strType, string strSubType, string strFieldRef, string strValue, string strValidation )
        {
            string strInputType;

            RFQFieldControl dtFieldControl = new RFQFieldControl();

            DataTable dt = dtFieldControl.GetRFQFieldControlInfo(strType, strSubType, strFieldRef);
            strInputType = (string)dt.Rows[0]["InputControlType"];
            strInputType = strInputType.ToUpper();

            if (strInputType.Contains("TEXTBOX"))
            {
                TextBox oText = new TextBox();
                oText.Text = strValue;
                return oText;

            }
            else
            {
                DropDownList oCBox = new DropDownList();
             //   ComboBox oCBox = new ComboBox();
              //  RadComboBox oCBox = new RadComboBox();
                oCBox.ID = "COMBO" + strFieldRef;
             
 

                RFQGenericDB oDb = new RFQGenericDB();

                dt = oDb.GetRecordSet(strValidation);

                foreach (DataRow oRow in dt.Rows)
                {

                    ListItem lstItem = new ListItem((string)oRow[0]);

                    oCBox.Items.Add(lstItem);
                }
                oCBox.Text  = strValue;
                oCBox.Enabled = true;
 
                return oCBox;
            }

            return null;
        }
        private void BuildNoteBox(ref TextBox  oText, string strControlName)
        {
            if (strControlName.ToUpper() == "NOTES")
            {

                oText.Height = new Unit(TEXTBOXNOTEHEIGHT, UnitType.Pixel);
                oText.Width = new Unit(TEXTBOXCELLWIDTH, UnitType.Pixel);
                oText.TextMode =  TextBoxMode.MultiLine;
            }            


        }
        public Control GetGridCellControlWR(string strRow, string strType, string strSubType, string strFieldRef, string strValue, string strValidation)
        {
            string strInputType;

            RFQFieldControl dtFieldControl = new RFQFieldControl();

            DataTable dt = dtFieldControl.GetRFQFieldControlInfo(strType, strSubType, strFieldRef);
            strInputType = (string)dt.Rows[0]["InputControlType"];
            strInputType = strInputType.ToUpper();

            if (strInputType.Contains("TEXTBOX"))
            {
                TextBox oText = new TextBox();
 
                BuildNoteBox(ref oText, (string)dt.Rows[0]["Description"]);
                
                oText.Text = strValue;
                oText.ID = "TEXTBOX" + "Row" + strRow + "_" + strFieldRef; 

                return oText;

            }
            else
            {
                DropDownList oCBox = new DropDownList();
                //   ComboBox oCBox = new ComboBox();
             
                oCBox.ID = "COMBO" + "Row" + strRow + "_" + strFieldRef;

      

                RFQGenericDB oDb = new RFQGenericDB();

                dt = oDb.GetRecordSet(strValidation);

                foreach (DataRow oRow in dt.Rows)
                {

                    ListItem lstItem = new ListItem((string)oRow[0]);

                    oCBox.Items.Add(lstItem);
                }
                oCBox.Text = strValue;
                oCBox.Enabled = true;

                return oCBox;
            }

            return null;
        }

        public Control GetGridCellControl(string strType, string strSubType, string strFieldRef, string strValidation)
        {
            string strInputType;

            RFQFieldControl dtFieldControl = new RFQFieldControl();
           

            DataTable dt = dtFieldControl.GetRFQFieldControlInfo(strType, strSubType, strFieldRef);
            strInputType = (string)dt.Rows[0]["InputControlType"];
            strInputType = strInputType.ToUpper();

            if (strInputType.Contains("TEXTBOX"))
            {
                TextBox oText = new TextBox();
                BuildNoteBox(ref oText, (string)dt.Rows[0]["Description"]);
                return oText;

            }
            else
            {
                DropDownList oCBox = new DropDownList();
                oCBox.ID = "COMBO"+strFieldRef;
                //   ComboBox oCBox = new ComboBox();
       

                RFQGenericDB oDb = new RFQGenericDB();

                dt = oDb.GetRecordSet(strValidation);

                foreach (DataRow oRow in dt.Rows)
                {
                    ListItem lstItem = new ListItem((string)oRow[0]);

                    oCBox.Items.Add(lstItem);
                }
 
                return oCBox;
            }

            return null;
        }
        public Control GetGridCellControlWR(string strRow, string strType, string strSubType, string strFieldRef, string strValidation)
        {
            string strInputType;

            RFQFieldControl dtFieldControl = new RFQFieldControl();


            DataTable dt = dtFieldControl.GetRFQFieldControlInfo(strType, strSubType, strFieldRef);
            strInputType = (string)dt.Rows[0]["InputControlType"];
            strInputType = strInputType.ToUpper();

            if (strInputType.Contains("TEXTBOX"))
            {
                TextBox oText = new TextBox();
                oText.ID = "TEXTBOX" + "Row" + strRow + "_" + strFieldRef; 
                return oText;

            }
            else
            {
                DropDownList oCBox = new DropDownList();
                oCBox.ID = "COMBO" + "Row" + strRow + "_"+ strFieldRef;
                //   ComboBox oCBox = new ComboBox();
     

                RFQGenericDB oDb = new RFQGenericDB();

                dt = oDb.GetRecordSet(strValidation);

                foreach (DataRow oRow in dt.Rows)
                {
                    ListItem lstItem = new ListItem((string)oRow[0]);

                    oCBox.Items.Add(lstItem);
                }

                return oCBox;
            }

            return null;
        }

    }
}