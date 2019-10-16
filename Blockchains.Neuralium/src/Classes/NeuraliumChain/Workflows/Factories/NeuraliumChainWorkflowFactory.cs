using System;
using Blockchains.Neuralium.Classes.NeuraliumChain.Providers;
using Blockchains.Neuralium.Classes.NeuraliumChain.Workflows.Creation.Messages.Elections;
using Blockchains.Neuralium.Classes.NeuraliumChain.Workflows.Creation.Transactions;
using Blockchains.Neuralium.Classes.NeuraliumChain.Workflows.debugging;
using Neuralia.Blockchains.Common.Classes.Blockchains.Common.Events.Transactions.Identifiers;
using Neuralia.Blockchains.Common.Classes.Blockchains.Common.Models;
using Neuralia.Blockchains.Common.Classes.Blockchains.Common.Workflows.Chain;
using Neuralia.Blockchains.Common.Classes.Blockchains.Common.Workflows.Creation.Messages.Elections;
using Neuralia.Blockchains.Common.Classes.Blockchains.Common.Workflows.Creation.Transactions;
using Neuralia.Blockchains.Common.Classes.Blockchains.Common.Workflows.Factories;
using Neuralia.Blockchains.Common.Classes.Blockchains.Common.Workflows.Messages;
using Neuralia.Blockchains.Core;
using Neuralia.Blockchains.Core.Configuration;
using Neuralia.Blockchains.Core.General.Types;
using Neuralia.Blockchains.Core.General.Types.Specialized;
using Neuralia.Blockchains.Core.P2p.Connections;
using Neuralia.Blockchains.Tools.Data;

namespace Blockchains.Neuralium.Classes.NeuraliumChain.Workflows.Factories {
	public interface INeuraliumChainWorkflowFactory : IChainWorkflowFactory<INeuraliumCentralCoordinator, INeuraliumChainComponentProvider> {

		IInsertDebugConfirmWorkflow CreateDebugConfirmChainWorkflow(TransactionId guid, SafeArrayHandle hash);

		IInsertDebugMessageWorkflow CreateDebugMessageWorkflow();

		ICreateNeuraliumTransferTransactionWorkflow CreateSendNeuraliumsWorkflow(Guid accountUuid, AccountId targetAccountId, Amount amount, Amount tip, string note, CorrelationContext correlationContext);
#if TESTNET || DEVNET
		ICreateNeuraliumRefillTransactionWorkflow CreateRefillNeuraliumsWorkflow(Guid accountUuid, CorrelationContext correlationContext);
#endif
	}

	public class NeuraliumChainWorkflowFactory : ChainWorkflowFactory<INeuraliumCentralCoordinator, INeuraliumChainComponentProvider>, INeuraliumChainWorkflowFactory {
		public NeuraliumChainWorkflowFactory(INeuraliumCentralCoordinator centralCoordinator) : base(centralCoordinator) {
		}

		public override ICreatePresentationTransactionWorkflow<INeuraliumCentralCoordinator, INeuraliumChainComponentProvider> CreatePresentationTransactionChainWorkflow(CorrelationContext correlationContext, Guid? accountUuId) {
			return new NeuraliumCreatePresentationTransactionWorkflow(this.centralCoordinator, correlationContext, accountUuId);
		}

		public override ICreateChangeKeyTransactionWorkflow<INeuraliumCentralCoordinator, INeuraliumChainComponentProvider> CreateChangeKeyTransactionWorkflow(byte changingKeyOrdinal, string note, CorrelationContext correlationContext) {
			return new NeuraliumCreateChangeKeyTransactionWorkflow(this.centralCoordinator, note, changingKeyOrdinal, correlationContext);
		}

		public virtual IInsertDebugConfirmWorkflow CreateDebugConfirmChainWorkflow(TransactionId guid, SafeArrayHandle hash) {
			return new InsertDebugConfirmWorkflow(guid, hash, this.centralCoordinator);
		}

		public virtual ICreateNeuraliumTransferTransactionWorkflow CreateSendNeuraliumsWorkflow(Guid accountUuid, AccountId targetAccountId, Amount amount, Amount tip, string note, CorrelationContext correlationContext) {
			return new CreateNeuraliumTransferTransactionWorkflow(accountUuid, targetAccountId, amount, tip, note, this.centralCoordinator, correlationContext);
		}

		public IInsertDebugMessageWorkflow CreateDebugMessageWorkflow() {
			return new InsertDebugMessageWorkflow(this.centralCoordinator);
		}

		public override ISendElectionsRegistrationMessageWorkflow<INeuraliumCentralCoordinator, INeuraliumChainComponentProvider> CreateSendElectionsCandidateRegistrationMessageWorkflow(AccountId candidateAccountId, ElectionsCandidateRegistrationInfo electionsCandidateRegistrationInfo, ChainConfigurations.RegistrationMethods registrationMethod, CorrelationContext correlationContext) {
			return new NeuraliumSendElectionsRegistrationMessageWorkflow(candidateAccountId, electionsCandidateRegistrationInfo, registrationMethod, this.centralCoordinator, correlationContext);
		}

		public override ILoadWalletWorkflow<INeuraliumCentralCoordinator, INeuraliumChainComponentProvider> CreateLoadWalletWorkflow(CorrelationContext correlationContext) {
			return new LoadWalletWorkflow<INeuraliumCentralCoordinator, INeuraliumChainComponentProvider>(this.centralCoordinator, correlationContext);
		}

#if TESTNET || DEVNET
		public virtual ICreateNeuraliumRefillTransactionWorkflow CreateRefillNeuraliumsWorkflow(Guid accountUuid, CorrelationContext correlationContext) {
			return new CreateNeuraliumRefillTransactionWorkflow(accountUuid, null, this.centralCoordinator, correlationContext);
		}
#endif
	}
}