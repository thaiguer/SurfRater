package core.domain

class `WeatherUseCase.kt`(private val repository: `WeatherRepository.kt`) {
    suspend fun getConvertedTemperature(): Double {
        return repository.fetchTemperature()
    }
}