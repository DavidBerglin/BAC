import { Component, inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);

  currentUser: string = '';
  userRole: number = 0;
  note: any = null;
  allNotes: any[] = [];
  apiUrl = 'http://localhost:5029/api/notes';
  fetch = "fetch('http://localhost:5029/api/notes/2', { headers: { 'X-User': 'Olle' } }).then(res => res.json()).then(data => app.note = data);";
  adminFetchAll = "fetch('http://localhost:5029/api/notes/admin/all', { headers: { 'X-User': 'Admin' } }).then(res => res.json()).then(data => app.allNotes = data);";

  ngOnInit() {
    (window as any).app = this;
  }

  login(name: string, role: number) {
    this.currentUser = name;
    this.userRole = role;
    this.note = null;
    this.allNotes = [];
  }

  logout() {
    this.currentUser = '';
    this.note = null;
    this.allNotes = [];
  }

  getNote(id: number) {
    this.allNotes = [];
    const headers = { 'X-User': this.currentUser };
    this.http.get(`${this.apiUrl}/${id}`, { headers })
      .subscribe({
        next: (data) => this.note = data,
        error: (err) => alert("Åtkomst nekad!")
      });
  }

  getAllNotes() {
    this.note = null;
    const headers = { 'X-User': this.currentUser };
    this.http.get<any[]>(`${this.apiUrl}/admin/all`, { headers })
      .subscribe({
        next: (data) => this.allNotes = data,
        error: (err) => alert("Enbart för admin!")
      });
  }

  exportData() {
    this.note = null;
    const headers = { 'X-User': this.currentUser };
    this.http.get<any[]>(`${this.apiUrl}/export/all-data-raw`, { headers })
      .subscribe({
        next: (data) => this.allNotes = data,
        error: (err) => alert("Servern stoppade exporten!")
      });
  }
}
