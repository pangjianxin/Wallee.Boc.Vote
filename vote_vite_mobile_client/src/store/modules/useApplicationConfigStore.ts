import { defineStore } from "pinia";
import { AbpApplicationConfigurationService } from "/@/openapi/index";
import type {
  ApplicationAuthConfigurationDto,
  ApplicationConfigurationDto,
  ApplicationLocalizationConfigurationDto,
  ApplicationSettingConfigurationDto,
  CurrentTenantDto,
  CurrentUserDto,
} from "/@/openapi/index";

export default defineStore("applicationConfig", {
  state: (): ApplicationConfigurationDto => {
    return {
      localization: undefined,
      auth: undefined,
      setting: undefined,
      currentUser: undefined,
      multiTenancy: undefined,
      currentTenant: undefined,
      timing: undefined,
      clock: undefined,
    };
  },
  getters: {
    getLocalization(): ApplicationLocalizationConfigurationDto | undefined {
      return this.localization;
    },
    getAuth(): ApplicationAuthConfigurationDto | undefined {
      return this.auth;
    },
    getSetting(): ApplicationSettingConfigurationDto | undefined {
      return this.setting;
    },
    getCurrentUser(): CurrentUserDto | undefined {
      return this.currentUser;
    },
    getCUrrentUserName(): string | null | undefined {
      return this.currentUser?.name;
    },
    isAuthenticated(): boolean | undefined {
      return this.currentUser?.isAuthenticated;
    },
    getCurrentTenant(): CurrentTenantDto | undefined {
      return this.currentTenant;
    },
  },
  actions: {
    async initConfig() {
      const res =
        await AbpApplicationConfigurationService.abpApplicationConfigurationGet(
          { includeLocalizationResources: false }
        );
      if (res) this.store(res);
    },
    store(config: ApplicationConfigurationDto) {
      this.localization = config.localization;
      this.auth = config.auth;
      this.setting = config.setting;
      this.currentUser = config.currentUser;
      this.currentTenant = config.currentTenant;
    },
    isPermited(permission: string): boolean {
      let policies = this.auth?.grantedPolicies;
      if (policies) {
        return policies[permission]?.valueOf() === true ?? false;
      } else {
        return false;
      }
    },
  },
  persist: {
    storage: localStorage,
    paths: ["localization", "auth", "setting", "currentUser", "currentTenant"],
    key: "app-config",
  },
});
