namespace Pathwaze.Client.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductService> _logger;

    public ProductService(HttpClient httpClient, ILogger<ProductService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<ProductDto> GetProduct(Guid productId)
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{_httpClient.BaseAddress!.AbsoluteUri}/GetProduct/{productId}");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductDto>(stringContent);
                return result!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ProductService.GetProduct failed with: " + ex.Message);
        }
        return null!;
    }

    public async Task<List<ProductDto>> GetAllProducts()
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{_httpClient.BaseAddress!.AbsoluteUri}/GetAllProducts");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductDto>>(stringContent);
                return result!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ProductService.GetAllProducts failed with: " + ex.Message);
        }
        return null!;
    }

    public async Task<List<ProductDto>> GetProductsByGroceryStore(Guid groceryStoreId)
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{_httpClient.BaseAddress!.AbsoluteUri}/GetProductsByGroceryStore/{groceryStoreId}");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductDto>>(stringContent);
                return result!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ProductService.GetProductsByGroceryStore failed with: " + ex.Message);
        }
        return null!;
    }

    public async Task<List<ProductDto>> GetProductsBySupplier(Guid supplierId)
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{_httpClient.BaseAddress!.AbsoluteUri}/GetProductsBySupplier/{supplierId}");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductDto>>(stringContent);
                return result!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ProductService.GetProductsBySupplier failed with: " + ex.Message);
        }
        return null!;
    }

    public async Task<bool> CreateProduct(ProductDto product)
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{_httpClient.BaseAddress!.AbsoluteUri}/CreateProduct");
            string jsonRequest = JsonConvert.SerializeObject(product);
            httpRequest.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(stringContent);
                return result!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ProductService.CreateProduct failed with: " + ex.Message);
        }
        return false;
    }

    

    public async Task<bool> UpdateProduct(ProductDto product)
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Put, $"{_httpClient.BaseAddress!.AbsoluteUri}/UpdateProduct");
            string jsonRequest = JsonConvert.SerializeObject(product);
            httpRequest.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(stringContent);
                return result!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ProductService.UpdateProduct failed with: " + ex.Message);
        }
        return false;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"{_httpClient.BaseAddress!.AbsoluteUri}/DeleteProduct/{productId}");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(stringContent);
                return result!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ProductService.DeleteProduct failed with: " + ex.Message);
        }
        return false;
    }
}
