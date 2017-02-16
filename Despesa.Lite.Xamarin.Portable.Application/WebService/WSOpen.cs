using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Xamarin.Portable.Aplicacao.WebService
{
    public class WSOpen
    {
        public static async Task<T> Get<T>(string link)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Constantes.TokenUsuario);

            var response = await client.GetAsync(link);
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                var obj = JsonConvert.DeserializeObject<T>(content);
                return obj;
            }
            catch
            {
                return default(T);
            }
        }

        public static async Task<T> Post<T>(string link, T obj)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Constantes.TokenUsuario);
            var objser = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var json = JsonConvert.SerializeObject(obj);
            try
            {
                var response = await client.PostAsync(link, objser);
                var content = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)
                {
                   
                    var objdes = JsonConvert.DeserializeObject<T>(content);
                    return objdes;
                }
                else
                {
                    return default(T);
                }

            }
            catch
            {
                return default(T);
            }
        }

        public static async Task<T> Put<T>(string link, T obj)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Constantes.TokenUsuario);
            var objser = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PutAsync(link, objser);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var objdes = JsonConvert.DeserializeObject<T>(content);
                    return objdes;
                }
                else
                {
                    return default(T);
                }

            }
            catch
            {
                return default(T);
            }
        }

        public static async Task<bool> Delete<T>(string link)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Constantes.TokenUsuario);
            try
            {
                var response = await client.DeleteAsync(link);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> GetToken(string usuario, string senha)
        {
            string link = Constantes.Server + Constantes.Server_Token;
            string user = string.Format("grant_type=password&username={0}&password={1}",usuario,senha);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var teste2 = JsonConvert.SerializeObject(user);
            var content = new StringContent(user, Encoding.UTF8, "application/json");
            
            try
            {
                var response = await client.PostAsync(link, content);
                var teste = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    Token.Token token =  JsonConvert.DeserializeObject<Token.Token>(await response.Content.ReadAsStringAsync());
                    Constantes.TokenUsuario = token.access_token;
                    return true;
                }else
                {
                    Constantes.TokenUsuario = null;
                    return false;
                }

            } catch
            {
                return false;
            }
        }

        public static async Task<bool> Registrar(string nome, string email, string password,string confirmpassword, bool companhia)
        {
            string link = Constantes.Server + Constantes.Server_Register;
            var usuarioregistro = new { email = email, password = password, confirmpassword = confirmpassword, nome = nome, companhia = companhia };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var objser = JsonConvert.SerializeObject(usuarioregistro);

            var content = new StringContent(objser, Encoding.UTF8,"application/json");
            try
            {
                var response = await client.PostAsync(link, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

    }
}
