import { Directive, DirectiveBinding, App } from "vue";
import useApplicationConfigStore from "/@/store/modules/useApplicationConfigStore";

const mounted = (el: Element, binding: DirectiveBinding<any>) => {
  const { isPermited } = useApplicationConfigStore();
  const value = binding.value;
  if (!value) return;
  if (!isPermited(value)) {
    // el.setAttribute("disabled", "disabled");
    el.parentNode?.removeChild(el);
  }
};

const permissionDirective: Directive = {
  mounted,
};

export function setupPermissionDirective(app: App) {
  app.directive("permission", permissionDirective);
}

export default permissionDirective;
