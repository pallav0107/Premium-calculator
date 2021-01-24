import { AppConfigService } from './app-config.service';

export function AppConfigServiceFactory(appConfig: AppConfigService) {
    return () => {
        return appConfig.loadAppConfig();
    };
};