import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-subjects',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './subjects.component.html',
})
export class SubjectsComponent {
  subjects: string[] = [
    'Subject 1',
    'Subject 2',
    'Subject 3',
    'Subject 4',
    'Subject 5',
    'Subject 6'
  ];

  selectedSubject: string | null = null;

  selectSubject(subject: string) {
    this.selectedSubject = subject;
    console.log('Selected:', subject);
  }
}
