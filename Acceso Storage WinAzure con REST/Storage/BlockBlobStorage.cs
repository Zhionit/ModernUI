using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace Acceso_Storage_WinAzure_con_REST.Storage
{
    public class BlockBlobStorage
    {
        private const string X_MS_BLOCK_BLOB = "Block-Blob";
        private const string _X_MS_VERSION = "2012-02-12";

        // Cuenta que se nos brinda para acceder al Storage
        public string Account { get; set; }

        // Clave para acceder a la cuenta del Storage
        public string Key { get; set; }

        public BlockBlobStorage(string account, string key)
        {
            Account = account;
            Key = key;
        }

        /* Método asyncrono que sube un archivo a la nube
         * String blobname = nombre el archivo
         * Stream stream = datos a subir
         * string mimetype = es la manera de identificar el tipo de un archivo sin tener que depender de la extención del archivo
         * */
        public async Task<HttpResponseMessage> UploadAsync(string blobname, Stream stream, string mimetype= "application/octect-stream")
        {
            // HttpClient hace el request a la storage
            var httpClient = new HttpClient();

            var content = new StreamContent(stream);
            var tmpdate = RFC1123DateTime;
            // Los encabezados son pedidos por Win Azure para validar ciertas cosas antes de subir el contenido
            #region Headers
            // Definimos en tipo de contenido en el header
            content.Headers.ContentType = new MediaTypeHeaderValue(mimetype);

            // Se llaman headers canonicos todos aquellos header que inicien con "x-ms-"  TIENEN QUE ESTAR ORDENADOS ALFABETICAMENTE
            string signature = CreateSignature(
                HTTPVerb: "PUT" ,
                ContentLength: stream.Length.ToString() ,
                ContentType: mimetype ,
                CanonicalizedHeaders: "x-ms-blob-type:BlockBlop\nx-ms-date:" + tmpdate + "\nx-ms-version:2012-02-12" ,
                CanonicalizedResource: string.Format("/{0}/{1}" , Account , blobname)
                );

            // El tamaño del contenido -Large- Cuando se crea el objeto Stream el trae ese valor internamente 
            // Este valor se copia cuando se crea el Streamcontent

            // Se hace la definición de la fecha en la que se crea el request 
            // Por medio de "x-ms-date" Que modifica la fecha sin importar si la API Que usamos lo hace ya, la fecha tiene que estar en formato RFC1123
            httpClient.DefaultRequestHeaders.Add("x-ms-date" , tmpdate);

            // Manipulación de la versión
            httpClient.DefaultRequestHeaders.Add("x-ms-version", _X_MS_VERSION);

            // Tipo de Blob
            httpClient.DefaultRequestHeaders.Add("x-ms-blob-type", X_MS_BLOCK_BLOB);

            // Header de autorización, este es el que indica a Win Azure que tenemos permiso de subir el archivo a donde queremos
            httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("SharedKey {0}:{1}", Account, signature));

            #endregion

            /** El request de tipo PUT Para subir archivo a Win Azure -Ver documentación-
             * {0} = Nombre de la cuenta que se tiene en Win Azure
             * {1} = Nombre del objeto que se va a crear, con container incluido
            /**/
            return await httpClient.PutAsync(string.Format("http//{0}.blob.core.windows.net/{1}", Account, signature), content);
        }

        /**Para crear el header de autorización para acceder a Win Azure -Ver documentación- Hay que seguir los esquemas de autorización
         * Se envian los valores de varios de losencabezados que se envían en los request concatenados unos con otros y separados por \n
         * VERB = Que estamos haciento, put, post, delete
         * **/
        private string CreateSignature(
                string HTTPVerb = "" ,
                string ContentEncoding = "" ,
                string ContentLanguage = "" ,
                string ContentLength = "" ,
                string ContentMD5 = "" ,
                string ContentType = "" ,
                string Date = "" ,
                string IfModifiedSince = "" ,
                string IfMatch = "" ,
                string IfNoneMatch = "" ,
                string IfUnmodifiedSince = "" ,
                string Range = "" ,
                string CanonicalizedHeaders = "" ,
                string CanonicalizedResource = ""
            )
        {
            /**
             * Toda la infromación que se envia a Win Azure se concatena para luego aplicar un algoritmo (utf-8 => HMAC-SHA256) y luego hacer un hash
             * Win Azure al recibir lo enviado hace las mismas operaciones y verifica que el hash que se dio como resultado es el mismo, por provacidad
             * **/
            var sumstring = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}\n{11}\n{12}\n{13}",
                HTTPVerb, ContentEncoding, ContentLanguage, ContentLength, ContentMD5, ContentType, Date, IfModifiedSince, IfMatch, IfNoneMatch, IfUnmodifiedSince, Range, CanonicalizedHeaders, CanonicalizedResource
                );

            return computeHMAC_SHA256(sumstring);
        }

        // Metodo encarado de aplicar el algoritmo HMAC-SHA256 después de convertir la cadena a utf-8
        private string computeHMAC_SHA256(string input)
        {
            var algoritmo = MacAlgorithmProvider.OpenAlgorithm("HMAC-SHA256");

            // Convierte el input en un CryptographicBuffer Utf-8
            var inputBuffer = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);

            // Se prepara la llave porque esta en base64 a formato binario
            var keybuffer = CryptographicBuffer.DecodeFromBase64String(Key);

            // Para usar la Key en el algoritmo necesitamos convertirla en un tipo HMAC
            var hmackey = algoritmo.CreateKey(inputBuffer);

            // Ahora procedemos a firmar el contenido digital
            var singbuffer = CryptographicEngine.Sign(hmackey , inputBuffer);
            return CryptographicBuffer.EncodeToBase64String(singbuffer);
        }

        /** Propiedad que me establece el horario actual con respecto al meridiano de greenwish con el formato RFC1123 
         * Primer argumento nos indica el formato RFC1123
         * Segundo argumento nos dice respecto a que cultura se debe conservar el estandar
        **/
        public string RFC1123DateTime { get { return DateTime.UtcNow.ToString("R" , CultureInfo.InvariantCulture); } }
    }
}

