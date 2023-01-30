using Azure.Storage.Blobs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Revista_digital.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Revista_digital.Servicios
{
    class GestionPDFService
    {
        private Articulo articulo;
        public void GenerarPdf(Articulo articuloModel)
        {
            articulo = articuloModel;

            WebClient mywebClient = new WebClient();
            mywebClient.DownloadFile(articulo.Imagen, "downloadedImage.png");

            byte[] imageData = File.ReadAllBytes("downloadedImage.png");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text(articulo.Titulo)
                        .SemiBold().FontSize(36).FontColor(Colors.LightGreen.Medium);

                    page.Content()
                        .PaddingVertical(1, QuestPDF.Infrastructure.Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Item().Text(articulo.Seccion).FontSize(25).SemiBold();
                            x.Spacing(20);
                            x.Item().Image(imageData);
                            x.Spacing(5);
                            x.Item().Text(articulo.Cuerpo);
                            
                        });

                    page.Footer()
                        .AlignLeft()
                        .Text(x =>
                        {
                            x.Span("Autor: ");
                            x.Span(articulo.Autor);
                        });
                    page.Footer()
                        .AlignRight()
                        .Column(x =>
                        {
                            x.Item().Image(articulo.Autor/*.redSocial*/);
                            x.Item().Text(articulo.Autor/*.NickName*/);
                        });
                });
            })
            .GeneratePdf(articulo.Titulo+".pdf");
            SubirPDF();
            DeleteFiles();
        }

        private void DeleteFiles()
        {
            File.Delete("downloadedImage.png");
            File.Delete("Articulo.pdf");
        }

        private void SubirPDF()
        {
            var clienteBlobService = new BlobServiceClient("CADENA DE CONEXION");
            var clienteContenedor = clienteBlobService.GetBlobContainerClient("ArticulosPDF");
            clienteContenedor.CreateIfNotExists();

            Stream streamPdf = File.OpenRead(articulo.Titulo + ".pdf");
            string nombrePdf = Path.GetFileName(articulo.Titulo + ".pdf");
            clienteContenedor.UploadBlob(nombrePdf, streamPdf);
        }
    }
}
