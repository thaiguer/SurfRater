package core.data

class `WeatherRepository.kt` {
    suspend fun fetchTemperature(): Double {
        val response = ApiClient.service.getWeather()
        return response.temp * 1.8 + 32 // Convert Celsius to Fahrenheit
    }
}