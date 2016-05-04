#region Copyright Syncfusion Inc. 2001 - 2016
//
//  Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.Serialization;
using PresentacionEscritorio;
using System.Windows.Forms;

namespace Syncfusion.Windows.Forms.Diagram.Samples
{
    [Serializable()]
    [TypeConverter(typeof(MySymbolConverter))]
    public class MiProceso : Group
    {
        public MiProceso()
        {
            MessageBox.Show("dasdas");
        }

        public MiProceso(PointF[] pts)
        {
            Polygon polygon = new Polygon(pts);
            polygon.Name = "Polygon";
            FillStyleType fillStyleType = FillStyleType.LinearGradient;
            polygon.FillStyle.Type = fillStyleType;
            Color foreColor = Color.DarkSeaGreen;
            polygon.FillStyle.ForeColor = foreColor;
            Color color = Color.White;
            polygon.FillStyle.Color = color;
            polygon.EditStyle.AllowSelect = false;
            this.Labels.Add(new Label());
            this.Labels[0].TextCase = TextCases.AllLower;
            this.Labels[0].Text = "aaa";
            this.AppendChild(polygon);
        }
        
        public MiProceso(MiProceso src)
            : base(src)
        { }

        protected MiProceso(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // The Serialization constructor is invoked during deserialization or during a drag & drop operation.
            // If the MySymbol type has serializable members, then initialize them with the serialized data 
            // obtained from the SerializationInfo param
        }

        public FillStyleType FillStyleType
        {
            get { return ((Polygon)this.Nodes[0]).FillStyle.Type; }
            set { ((Polygon)this.Nodes[0]).FillStyle.Type = value; }
        }

        public Color Color
        {
            get { return ((Polygon)this.Nodes[0]).FillStyle.Color; }
            set { ((Polygon)this.Nodes[0]).FillStyle.Color = value; }
        }

        public Color ForeColor
        {
            get { return ((Polygon)this.Nodes[0]).FillStyle.ForeColor; }
            set { ((Polygon)this.Nodes[0]).FillStyle.ForeColor = value; }
        }

        public string Texto
        {
            get { return this.Labels[0].Text; }
            set { this.Labels[0].Text = value; }
        }

        public string IDProceso { get { return this.Name; } set { this.Name = value; } }

        public override object Clone()
        {
            return new MiProceso(this);
        }
    }

    public class MySymbolConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            Attribute[] attrs = new Attribute[]
			{
				new BrowsableAttribute(true)
			};

            // This code returns only the specified properties. It can be used to filter out
            // properties that you do not wish to expose to in property grid.
            PropertyDescriptor[] props = new PropertyDescriptor[5];
            props[0] = TypeDescriptor.CreateProperty(typeof(MiProceso), "Color", typeof(Color), attrs);
            props[1] = TypeDescriptor.CreateProperty(typeof(MiProceso), "ForeColor", typeof(Color), attrs);
            props[2] = TypeDescriptor.CreateProperty(typeof(MiProceso), "FillStyleType", typeof(FillStyleType), attrs);
            props[3] = TypeDescriptor.CreateProperty(typeof(MiProceso), "IDProceso", typeof(string), attrs);
            props[4] = TypeDescriptor.CreateProperty(typeof(MiProceso), "Texto", typeof(string), attrs);
            return new PropertyDescriptorCollection(props);
        }
    }

    /////////////////////////////////
    //[Serializable()]
    //[TypeConverter(typeof(MySymbolConverter))]
    //public class MySymbol : Group
    //{
    //    private int clickCount;
    //    private Polygon polygon;
    //    private Color color;
    //    private Color foreColor;
    //    private FillStyleType fillStyleType;

    //    public MySymbol()
    //    {
    //        ////////////////////////////////////////////////////////////////
    //         Add child nodes to the symbol programmatically
    //        ////////////////////////////////////////////////////////////////

    //         Add an outer rectangle
    //        Rectangle outerRect = new Rectangle(100, 100, 96, 72);
    //        outerRect.Name = "Rectangle";
    //        outerRect.FillStyle.Type = FillStyleType.LinearGradient;
    //        outerRect.FillStyle.ForeColor = Color.GhostWhite;
    //        outerRect.FillStyle.Color = Color.LightSkyBlue ;
    //        outerRect.EditStyle.AllowSelect = false;
    //        this.AppendChild(outerRect);
    //        // Add a polygon
    //        PointF[] pts=
    //            {
    //                 new Point(6, 36),
    //                new Point(48, 6),
    //                new Point(90, 36),
    //                new Point(48, 66)
					
    //            };

    //        Polygon polygon = new Polygon(pts);
    //        polygon.Name = "Polygon";
    //        polygon.FillStyle.Type = FillStyleType.LinearGradient;
    //        polygon.FillStyle.ForeColor = Color.DarkSeaGreen;
    //        polygon.FillStyle.Color = Color.White ;
    //        polygon.EditStyle.AllowSelect = false;
    //        this.AppendChild(polygon);

    //         Add a polygon
    //        PointF[] pts =
    //            {
    //                new Point(0, 0),
    //                new Point(10, 50),
    //                new Point(0, 100),
    //                new Point(90, 100),
    //                new Point(100, 50),
    //                new Point(90, 0)

    //            };
    //        polygon = new Polygon(pts);
    //        polygon.Name = "Polygon";
    //        fillStyleType = FillStyleType.LinearGradient;
    //        polygon.FillStyle.Type = fillStyleType;
    //        foreColor = Color.DarkSeaGreen;
    //        polygon.FillStyle.ForeColor = foreColor;
    //        color = Color.White;
    //        polygon.FillStyle.Color = color;
    //        polygon.EditStyle.AllowSelect = false;
    //        polygon.Labels.Add(new Label());
    //        polygon.Labels[0].Text = "aaaa";
    //        polygon.Labels[0].Position = Position.Center;
    //        polygon.Labels[0].Orientation = LabelOrientation.Auto;
    //        polygon.Labels[0].DirectionVertical = true;
    //        this.AppendChild(polygon);

                  
    //    }

    //    public MySymbol(MySymbol src)
    //        : base(src)
    //    { }

    //    protected MySymbol(SerializationInfo info, StreamingContext context)
    //        : base(info, context)
    //    {
    //         The Serialization constructor is invoked during deserialization or during a drag & drop operation.
    //         If the MySymbol type has serializable members, then initialize them with the serialized data 
    //         obtained from the SerializationInfo param
    //    }

    //    public FillStyleType FillStyleType
    //    {
    //        get { return fillStyleType; }
    //        set
    //        {
    //            fillStyleType = value;
    //            polygon.FillStyle.Type = FillStyleType;
    //        }
    //    }

    //    public Color Color
    //    {
    //        get { return color; }
    //        set
    //        {
    //            color = value;
    //            polygon.FillStyle.Color = color;
    //        }
    //    }

    //    public Color ForeColor
    //    {
    //        get { return foreColor; }
    //        set
    //        {
    //            foreColor = value;
    //            polygon.FillStyle.ForeColor = foreColor;
    //        }
    //    }

    //    public int ClickCount
    //    {
    //        get { return clickCount; }
    //    }

    //    [EventHandlerPriority(true)]
    //    protected override void OnMouseClick(EventArgs e)
    //    {
    //        clickCount = clickCount + 1;
    //    }

    //    public override object Clone()
    //    {
    //        return new MySymbol(this);
    //    }
    //}
}
