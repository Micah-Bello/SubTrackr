import { useEffect, useState } from "react";
import axiosClient from "../api/axiosClient";

interface Subscription {
  id: number;
  name: string;
  price: number;
  billingCycle: string;
  nextBillingDate: string;
}

export default function SubscriptionsPage() {
  const [subscriptions, setSubscriptions] = useState<Subscription[]>([]);

  useEffect(() => {
    axiosClient.get<Subscription[]>("/subscriptions")
      .then((response) => {
        setSubscriptions(response.data);
      })
      .catch((error) => {
        console.error("Failed to fetch subscriptions", error);
      });
  }, []);

  return (
    <div style={{ maxWidth: 800, margin: "0 auto" }}>
      <h2>My Subscriptions</h2>
      <ul>
        {subscriptions.map(sub => (
          <li key={sub.id}>
            {sub.name} - ${sub.price} ({sub.billingCycle})
          </li>
        ))}
      </ul>
    </div>
  );
}
