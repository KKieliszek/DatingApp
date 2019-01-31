import { Injectable } from '@angular/core';
import { CanDeactivate} from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable()
export class PreventUnsavedChangesGuard implements CanDeactivate<MemberEditComponent> {
  constructor() {}

   canDeactivate(compnent: MemberEditComponent) {
    if (compnent.editForm.dirty) {
      return confirm('Are you sure you want to continue? Any unsaved changes will be lost');
    }
    return true;
  }
}
