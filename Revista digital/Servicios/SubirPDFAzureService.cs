using Azure.Storage.Blobs;
using Revista_digital.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_digital.Servicios
{
    class SubirPDFAzureService
    {
        public string SubirPDF(Articulo articulo)
        {
            var clienteBlobService = new BlobServiceClient("CADENA DE CONEXION");
            var clienteContenedor = clienteBlobService.GetBlobContainerClient("ArticulosPDF");
            clienteContenedor.CreateIfNotExists();

            Stream streamPdf = File.OpenRead(articulo.Titulo + ".pdf");
            string nombrePdf = Path.GetFileName(articulo.Titulo + ".pdf");
            clienteContenedor.UploadBlob(nombrePdf, streamPdf);

            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombrePdf);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;
            
            return urlImagen;
        }
    }
}
