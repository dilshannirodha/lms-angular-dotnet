import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SubjectsComponent } from '../subjects/subjects.component';

@Component({
  selector: 'app-student-layout',
  standalone: true,
  imports: [CommonModule, RouterModule,SubjectsComponent ],
  templateUrl: './student-layout.component.html',
})
export class StudentLayoutComponent {}
