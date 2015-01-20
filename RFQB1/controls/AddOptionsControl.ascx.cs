using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public delegate void CheckChangedEventHandler(object sender, EventArgs e);

public partial class controls_RadioButtonImage : System.Web.UI.UserControl
{
    /// <summary>
    /// Property to set the imageurl of the image.
    /// </summary>
    public string ImageUrl
    {
        get { return Image1.ImageUrl; }
        set { Image1.ImageUrl = value; }
    }

    /// <summary>
    /// Property to set the Checkboxes text property.
    /// </summary>
    public string CheckBoxText
    {
        get { return CheckBox1.Text; }
        set { CheckBox1.Text = value; }
    }

    /// <summary>
    /// Property to set the checkboxes checked property.
    /// </summary>
    public bool CheckBoxChecked
    {
        get { return CheckBox1.Checked; }
        set { CheckBox1.Checked = value; }
    }

    public bool AutoPostBack
    {
        get { return CheckBox1.AutoPostBack; }
        set { CheckBox1.AutoPostBack = value; }
    }

    public event CheckChangedEventHandler CheckChanged;
    protected virtual void OnCheckChanged(EventArgs e)
    {
        if (CheckChanged != null)
        {
            CheckChanged(this, e);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Capture the check changed event for the publicly exposed event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        OnCheckChanged(EventArgs.Empty);
    }

  
}