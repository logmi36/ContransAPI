using CtrApp8.Models.cita;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace CtrApp8.Helpers
{
    public class CitaRep
    {



        public async Task<string> Imprimir(CitaB item)
        {


            Document doc = new Document(PageSize.A4, 2f, 2f, 20f, 20f);

            iTextSharp.text.Font fnt0 = FontFactory.GetFont("Arial", 10, Font.BOLD);
            iTextSharp.text.Font fnt1 = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
            iTextSharp.text.Font fnt4 = FontFactory.GetFont("Arial", 12, Font.BOLD);


            byte[] contents;
            using (var mem = new MemoryStream())
            {
                using (PdfWriter wri = PdfWriter.GetInstance(doc, mem))
                {


                    doc.Open();

                    doc.Add(new Paragraph(""));


                    //=========================================================== boleta de pago inicio



                    PdfPTable table = new PdfPTable(28);
                    table.WidthPercentage = 90F;
                    table.DefaultCell.UseAscender = true;
                    table.DefaultCell.UseDescender = true;


                    //===========================================================

                    Paragraph prh = new Paragraph();
                    PdfPCell cell = new PdfPCell(prh);
                    string txt = "";

                    //===========================================================

                    string url = "";
                    url = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\logo7.png");
                    url = url.Replace("..", "");


                    Image img = Image.GetInstance(url);
                    cell = new PdfPCell(img, true);
                    cell.MinimumHeight = 30;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 12;
                    cell.Rowspan = 2;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                    table.AddCell(cell);



                    prh = new Paragraph();
                    prh.Font = fnt4;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Nro. Cita";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.MinimumHeight = 16;
                    cell.Colspan = 6;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt4;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.MinimumHeight = 16;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);



                    prh = new Paragraph();
                    prh.Font = fnt4;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f01;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.MinimumHeight = 16;
                    cell.Colspan = 9;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    //===========================================================


                    prh = new Paragraph();
                    prh.Font = fnt4;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Fecha de Cita";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.MinimumHeight = 16;
                    cell.Colspan = 6;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt4;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.MinimumHeight = 16;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);



                    prh = new Paragraph();
                    prh.Font = fnt4;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f02;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.MinimumHeight = 16;
                    cell.Colspan = 9;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    //===========================================================


                    prh = new Paragraph();
                    prh.Font = fnt1;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    //cell.BackgroundColor = new iTextSharp.text.BaseColor(153, 179, 255);
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.MinimumHeight = 16;
                    cell.Colspan = 28;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    //===========================================================
                    //===========================================================
                    //===========================================================



                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "BL";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f03;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 13;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);



                    BarcodeQRCode barcodeQRCode = new BarcodeQRCode(item.f18, 20, 20, null);

                    img = barcodeQRCode.GetImage();
                    cell = new PdfPCell(img, true);
                    cell.MinimumHeight = 30;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 10;
                    cell.Rowspan = 8;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);


                    //===========================================================



                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Contenedor";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f04 + " - " + item.f05;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 13;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    //-----------------------------------------------------------



                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Tipo Cont.";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f06 + " " + item.f07;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 13;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    //-----------------------------------------------------------



                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Linea Naviera";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f08;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 13;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    //-----------------------------------------------------------



                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Tipo de Cita";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f09;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 13;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    //-----------------------------------------------------------



                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Placa";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f10;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 13;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    //-----------------------------------------------------------



                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Brevete";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f11;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 13;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    //-----------------------------------------------------------



                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = "Conductor";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = ":";
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    prh = new Paragraph();
                    prh.Font = fnt0;
                    prh.Alignment = Element.ALIGN_CENTER;
                    txt = item.f12;
                    prh.Add(txt);
                    cell = new PdfPCell(prh);
                    cell.MinimumHeight = 24;
                    cell.BorderWidthRight = 0f;
                    cell.BorderWidthLeft = 0f;
                    cell.BorderWidthBottom = 0f;
                    cell.BorderWidthTop = 0f;
                    cell.Colspan = 13;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);


                    //-----------------------------------------------------------


                    //==========================================================================



                    doc.Add(table);

                    doc.Close();

                }
                contents = mem.ToArray();
            }

            string ans;
            ans = Convert.ToBase64String(contents, 0, contents.Length);

            return ans;

        }




    }
}
