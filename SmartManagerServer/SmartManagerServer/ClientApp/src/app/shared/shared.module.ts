import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InteractionDialogComponent } from './dialogs/interaction-dialog/interaction-dialog.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';

import {MatDialogModule} from '@angular/material/dialog';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatNativeDateModule, MatRippleModule} from '@angular/material/core';
import {MatTableModule} from '@angular/material/table';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ProgressComponent } from './components/progress/progress.component';



@NgModule({
  declarations: [
    InteractionDialogComponent,
    ProgressComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule,
    MatAutocompleteModule,
    MatInputModule,
    MatIconModule,
    MatSnackBarModule,
    MatRippleModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  exports:[
    ProgressComponent
  ]
})
export class SharedModule { }
