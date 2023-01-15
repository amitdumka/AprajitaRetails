using System.Net.Http.Json;

//using System.Net.Http.Json;
using System.Text.Json;

namespace AprajitaRetails.Client
{
    public class ChunkedDataRequestDto
    {
        public bool FirstChunk = false;
        public byte[]? Data { get; set; }
        public string FileName { get; set; } = "";
        public long Offset { get; set; }
    }

    public interface IFilesManager
    {
        Task<List<string>> GetFileNames();

        Task<bool> UploadFileChunk(ChunkedDataRequestDto fileChunkDto);
    }

    public class WasmFilesManager : IFilesManager
    {
        private readonly HttpClient _http;

        public WasmFilesManager(HttpClient http)
        {
            _http = http;
        } //FilesManager

        public async Task<List<string>> GetFileNames()
        {
            try
            {
                var response = await _http.GetAsync("api/Files/GetFiles");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // Possible null reference return.
                return JsonSerializer.Deserialize<List<string>>(responseBody);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        } //GetFileNames

        public async Task<bool> UploadFileChunk(ChunkedDataRequestDto fileChunkDto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/Files/UploadFileChunk", fileChunkDto);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                return Convert.ToBoolean(responseBody);
            }
            catch (Exception)
            {
                return false;
            }
        } //UploadFileChunk
    }
}