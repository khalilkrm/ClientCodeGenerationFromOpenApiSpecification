export * from './values.service';
import { ValuesService } from './values.service';
export * from './values.serviceInterface';
export * from './weather-forecast.service';
import { WeatherForecastService } from './weather-forecast.service';
export * from './weather-forecast.serviceInterface';
export const APIS = [ValuesService, WeatherForecastService];
