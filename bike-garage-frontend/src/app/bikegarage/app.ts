import { ChangeDetectionStrategy, Component, OnInit, signal, isDevMode } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, Bike, API_BASE_URL } from '../api-client';

@Component({
  selector: 'app-root',
  imports: [CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    Client,
    { provide: API_BASE_URL, useValue: isDevMode() 
        ? 'https://localhost:7211' 
        : 'https://ca-bikegarage-api.proudisland-dc68c2ce.polandcentral.azurecontainerapps.io' }
  ]
})
export class AppComponent implements OnInit {
  bikes = signal<Bike[]>([]);
  loading = signal(true);

  modelLabels: Record<number, string> = {
    1: 'MTB',
    2: 'Landsväg',
    3: 'Gravel',
    4: 'Cyclocross',
    5: 'TimeTrial'
  };

  tierLabels: Record<number, string> = {
    1: 'Shimano 105',
    2: 'Ultegra',
    3: 'DuraAce'
  };

  constructor(private client: Client) {}

  ngOnInit(): void {
    this.client.bikeAll().subscribe({
      next: (data) => {
        this.bikes.set(data ?? []);
        this.loading.set(false);
      },
      error: (err) => {
        console.error('Nagot gick fel vid hamtning:', err);
        this.loading.set(false);
      }
    });
  }

  getModelLabel(model?: number): string {
    if (!model) {
      return 'Okand';
    }
    return this.modelLabels[model] ?? `Okand (${model})`;
  }

  getTierLabel(tier?: number): string {
    if (!tier) {
      return 'Okand';
    }
    return this.tierLabels[tier] ?? `Okand (${tier})`;
  }
}